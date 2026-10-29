function restrictChars2(e, obj) {
    return restrictChars(e, obj, 2);
}

function restrictChars3(e, obj) {
    return restrictChars(e, obj, 3);    
}

function restrictChars5(e, obj) {
    return restrictChars(e, obj, 5);
}


function restrictChars(e, obj, CHAR_AFTER_DP) {
    
    var validList = "-0123456789.";  // allowed characters in field   
    var key, keyChar;

    key = (window.event) ? e.which : e.keyCode; // getKey(e);
    if (key == null) return true;
    // control keys   
    // null, backspace, tab, carriage return, escape   
    if (key == 0 || key == 8 || key == 9 || key == 13 || key == 27)
        return true;
    // get character   
    keyChar = String.fromCharCode(key);
    // check valid characters   
    if (validList.indexOf(keyChar) != -1) {

        //Checking for "-" symbol        
        if (((obj.value.length + 1) > 1) && (keyChar == "-")) { //If length > 0 then "-" symbol is not allowed        
            return false;
        }
        else {
            if (obj.value.indexOf("-") > -1) {
                if (keyChar == "-") { return false; }   //Allow only one "-" symbol
            }
        }

        // check for existing decimal point   
        var dp = 0;
        if ((dp = obj.value.indexOf(".")) > -1) {
            if (keyChar == ".")
                return false;  // only one allowed   
            else {
                // room for more after decimal point?   
                if (obj.value.length - dp <= CHAR_AFTER_DP)
                    return true;
            }
        }
        else return true;
    }
    // not a valid character   
    return false;
}