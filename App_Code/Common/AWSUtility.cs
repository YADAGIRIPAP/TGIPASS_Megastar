using Amazon;
using Amazon.S3;
using Amazon.S3.IO;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CoolBlueAdmin.Utilities
{
    public class AWSUtility
    {
        private readonly IAmazonS3 _client;
        private readonly string _bucketName;
        private readonly string _subBucketName;
        private AWSUtility()
        {
            _client = new AmazonS3Client(RegionEndpoint.APSouth2);
            _bucketName = ConfigurationManager.AppSettings["AWSBucketName"].ToString();
            _subBucketName = ConfigurationManager.AppSettings["AWSSubBucketName"].ToString();
        }
        private static AWSUtility instance = null;

        public static AWSUtility Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AWSUtility();
                }
                return instance;
            }
        }
        public Stream ViewImageFromAWS(string fileNameInS3)
        {
            try
            {
                var request = new GetObjectRequest
                {
                    BucketName = _bucketName,
                    Key = fileNameInS3
                };

                using (var getObjectResponse = _client.GetObject(request))
                {
                    using (var responseStream = getObjectResponse.ResponseStream)
                    {
                        var stream = new MemoryStream();
                        responseStream.CopyTo(stream);
                        stream.Position = 0;
                        return stream;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Read object operation failed.", exception);
            }
        }
        public bool UploadImageToAWS(Stream localFilePath, string subDirectoryInBucket, string fileNameInS3)
        {
            try
            {
                TransferUtility utility = new TransferUtility(_client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
                if (string.IsNullOrEmpty(subDirectoryInBucket))
                {
                    request.BucketName = _bucketName;
                }
                else
                {
                    request.BucketName = _bucketName + @"/" + subDirectoryInBucket;
                }
                request.Key = fileNameInS3;
                request.InputStream = localFilePath;
                utility.Upload(request);
                return true;
            }
            catch (Exception exception)
            {
                return false;
                throw new Exception("Upload object operation failed.", exception);
            }
        }
        public bool UploadFileToAWS(Stream localFilePath, string fileNameInS3,string subfilePath)
        {
            string bucketName = _bucketName;
            string folderKey = NormalizeKeyPart(subfilePath);
            string fileKey = NormalizeKeyPart(fileNameInS3);
            string objectKey = string.IsNullOrEmpty(folderKey) ? fileKey : folderKey + "/" + fileKey;
            MemoryStream buffer = null;
            try
            {
                buffer = CopyToBuffer(localFilePath);

                PutObjectRequest request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.Key = objectKey;
                request.InputStream = buffer;
                request.AutoCloseStream = false;
                request.UseChunkEncoding = false;
                request.DisableDefaultChecksumValidation = true;
                _client.PutObject(request);

                // The new file is already in the folder. Remove only the previous file
                // in that same folder. Do not delete the folder key itself.
                DeleteSiblingFiles(bucketName, folderKey, objectKey);
                return true;
            }
            catch (Exception exception)
            {
                LogUploadFailure(exception, bucketName, objectKey, localFilePath);
                return false;
            }
            finally
            {
                if (buffer != null)
                    buffer.Dispose();
            }
        }

        private static MemoryStream CopyToBuffer(Stream source)
        {
            MemoryStream buffer = new MemoryStream();
            if (source == null)
                return buffer;

            if (source.CanSeek)
                source.Position = 0;
            source.CopyTo(buffer);
            if (source.CanSeek)
                source.Position = 0;
            buffer.Position = 0;
            return buffer;
        }

        private void DeleteSiblingFiles(string bucketName, string folderKey, string newObjectKey)
        {
            if (string.IsNullOrEmpty(folderKey))
                return;

            string prefix = folderKey + "/";
            ListObjectsV2Request listRequest = new ListObjectsV2Request();
            listRequest.BucketName = bucketName;
            listRequest.Prefix = prefix;

            ListObjectsV2Response listResponse;
            do
            {
                listResponse = _client.ListObjectsV2(listRequest);
                foreach (S3Object entry in listResponse.S3Objects)
                {
                    if (!entry.Key.StartsWith(prefix))
                        continue;

                    string nameInsideFolder = entry.Key.Substring(prefix.Length);
                    if (nameInsideFolder.Length == 0 || nameInsideFolder.IndexOf('/') >= 0)
                        continue;
                    if (entry.Key == newObjectKey)
                        continue;

                    _client.DeleteObject(new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = entry.Key
                    });
                }
                listRequest.ContinuationToken = listResponse.NextContinuationToken;
            }
            while (listResponse.IsTruncated);
        }

        private static string NormalizeKeyPart(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // S3 only treats / as a folder. A stored \ is shown in the console as a lookalike, not as a folder.
            char[] chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '\\' || chars[i] == '/' || chars[i] == '\uFF3C' || chars[i] == '\u2216' || chars[i] == '\uFE68' || chars[i] == '\u29F5' || chars[i] == '\uF05C')
                    chars[i] = '/';
            }
            string normalized = new string(chars).Trim().Trim('/');
            while (normalized.Contains("//"))
                normalized = normalized.Replace("//", "/");
            return normalized;
        }

        private void LogUploadFailure(Exception exception, string bucketName, string objectKey, Stream stream)
        {
            try
            {
                AmazonS3Exception s3Exception = exception as AmazonS3Exception;
                if (s3Exception == null && exception != null)
                    s3Exception = exception.InnerException as AmazonS3Exception;

                string details = "UploadFileToAWS failed.";
                details += Environment.NewLine + "BucketName: " + bucketName;
                details += Environment.NewLine + "Key: " + objectKey;
                if (s3Exception != null)
                {
                    details += Environment.NewLine + "ErrorCode: " + s3Exception.ErrorCode;
                    details += Environment.NewLine + "StatusCode: " + s3Exception.StatusCode;
                    details += Environment.NewLine + "RequestId: " + s3Exception.RequestId;
                    details += Environment.NewLine + "Message: " + s3Exception.Message;
                }
                details += Environment.NewLine + exception;
                LogErrorFile.LogData(details);
            }
            catch (Exception)
            {
            }
        }
        public bool DeleteImageFromAWS(string subDirectoryInBucket, string fileNameInS3)
        {
            try
            {
                var getObjectResponse = _client.DeleteObject(new DeleteObjectRequest() { BucketName = _bucketName, Key = subDirectoryInBucket + "/" + fileNameInS3 });
                return true;
            }
            catch (Exception exception)
            {
                return false;
                throw new Exception("Delete object operation failed.", exception);
            }
        }
        public bool DeleteFileFromAWS(string fileNameInS3)
        {
            try
            {
                string subDirectoryInBucket = _subBucketName;
                var getObjectResponse = _client.DeleteObject(new DeleteObjectRequest() { BucketName = _bucketName, Key = subDirectoryInBucket + "/" + fileNameInS3 });
                return true;
            }
            catch (Exception exception)
            {
                return false;
                throw new Exception("Delete object operation failed.", exception);
            }
        }
        public bool checkFileExist(string fileNameInS3)
        {
            try
            {
                S3FileInfo s3FileInfo = new S3FileInfo(_client, _bucketName, fileNameInS3);
                return s3FileInfo.Exists;
            }
            catch (Exception exception)
            {
                throw new Exception("Read object operation failed.", exception);
            }
        }
        public bool renameImageFileToAws(string subDirectoryInBucket, string oldfileNameInS3, string newfileNameInS3)
        {
            try
            {
                var copy = new CopyObjectRequest();
                copy.SourceBucket = _bucketName;
                copy.SourceKey = subDirectoryInBucket + "/" + oldfileNameInS3;
                copy.DestinationBucket = _bucketName;
                copy.DestinationKey = subDirectoryInBucket + "/" + newfileNameInS3;
                var copyResponse = _client.CopyObject(copy);

                if (copyResponse.HttpStatusCode.ToString().ToLower() == "ok")
                {
                    DeleteImageFromAWS(subDirectoryInBucket, oldfileNameInS3);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void DownloadObject(string fileNameInS3, string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileNameInS3
            };
            using (var getObjectResponse = _client.GetObject(request))
            {
                getObjectResponse.WriteResponseStreamToFile(HttpContext.Current.Server.MapPath("~/PDF/") + fileName);
            }

        }
        public bool CreateCopyImageFileAwsToAws(string oldfileNameInS3, string newfileNameInS3)
        {
            try
            {
                var copy = new CopyObjectRequest();
                copy.SourceBucket = _bucketName;
                copy.SourceKey = oldfileNameInS3;
                copy.DestinationBucket = _bucketName;
                copy.DestinationKey = newfileNameInS3;
                var copyResponse = _client.CopyObject(copy);

                if (copyResponse.HttpStatusCode.ToString().ToLower() == "ok")
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool MoveImageFileinAWS(string oldfileNameInS3, string newfileNameInS3)
        {
            try
            {
                var copy = new CopyObjectRequest();
                copy.SourceBucket = _bucketName;
                copy.SourceKey = oldfileNameInS3;
                copy.DestinationBucket = _bucketName;
                copy.DestinationKey = newfileNameInS3;
                var copyResponse = _client.CopyObject(copy);

                if (copyResponse.HttpStatusCode.ToString().ToLower() == "ok")
                {
                    DeleteImageFromAWS("Images", oldfileNameInS3.Replace("Images/", ""));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}