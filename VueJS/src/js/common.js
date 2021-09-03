var CommonFn = CommonFn || {};

/**
 * @param {} thisdate Xâu javascript date
 * @returns Xâu ở dạng yyyy-MM-dd
 *  Nguyễn Hùng 18/07
 */
CommonFn.formatDateYMD = thisdate => {
    date = new Date(thisdate);
    return date.getFullYear() + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + ("0" + date.getDate()).slice(-2);
};

/**
 * @param {} thisdate Xâu javascript date
 * @returns Xâu ở dạng dd/MM/yyyy
 */
CommonFn.formatDateDMY = thisdate => {
    date = new Date(thisdate);
    return ("0" + date.getDate()).slice(-2) + '/' + ("0" + (date.getMonth() + 1)).slice(-2) + '/' + date.getFullYear();
};

/**
 * 
 * @param {} myinput  xâu bất kỳ
 * @returns Xâu số (dấu ngăn . cách phần nghìn )
 */
CommonFn.formatMoney = myinput => {
    myinput += "";
    if (myinput != null) {
        myinput.replaceAll(".", "");

        let onlynumber = '';
        for (var i = 0; i < myinput.length; i++) {
            if (!isNaN(parseInt(myinput[i], 10))) {
                onlynumber += myinput[i];
            }
        }
        return (Number(onlynumber).toLocaleString('vi'));
    }
    return 0;
};

/**
 * @param {} myinput Xâu  input bất kỳ
 * @returns Xâu chỉ chứa số
 *  Nguyễn Hùng 18/07
 */
CommonFn.formatNumber = myinput => {
    myinput += "";
    if (myinput != null) {
        myinput.replaceAll(".", "")

        let onlynumber = '';
        for (var i = 0; i < myinput.length; i++) {
            if (!isNaN(parseInt(myinput[i], 10))) {
                onlynumber += myinput[i];
            }
        }
        return onlynumber;
    }
    return 0;
};

/**
 * 
 * @param {*} input xâu input cần validate
 * @param {*} dataType kiểu dữ liệu cần validate
 * @returns 
 */
CommonFn.validateInputFormat = (input, dataType) => {
    switch (dataType) {
        case 'HumanName':
            return CommonFn.validName(input);
        case 'Email':
            return CommonFn.validEmail(input);
        case 'PhoneNumber':
            return CommonFn.validPhoneNumber(input);
        case 'IdentityNumber':
            return CommonFn.validIdentity(input);
        default:
            if (input.length == 0)
                return 'Vui lòng nhập vào trường này';
            return 'Correct';
    }
}

/**
 * @param {} myname Xâu chứa tên cần validate
 * @returns Message Kết quả validate
 *  Nguyễn Hùng 18/07
 */
CommonFn.validName = myname => {
    if (myname.length == 0) return 'Vui lòng nhập vào trường này';
    for (var i = 0; i < myname.length; i++) {
        if (!isNaN(parseInt(myname[i], 10))) {
            return "Tên không được có chữ số";
        }
    }
    return 'Correct';
}

/**
 * @param {} myemail Xâu chứa email cần validate
 * @returns Message Kết quả validate
 *  Nguyễn Hùng 18/07
 */
CommonFn.validEmail = myemail => {
    if (myemail.length == 0) return 'Vui lòng nhập vào trường này';
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (re.test(String(myemail).toLowerCase()) == true) return 'Correct';
    return 'Định dạng email không hợp lệ';
}

/**
 * @param {} myid Xâu chứa CMTND/CCCD cần validate
 * @returns Message Kết quả validate
 *  Nguyễn Hùng 18/07
 */
CommonFn.validIdentity = myid => {
    if (myid.length == 0) return 'Vui lòng nhập vào trường này';
    if (myid.length == 9 || myid.length == 12) {
        for (var i = 0; i < myid.length; i++) {
            if (isNaN(parseInt(myid[i], 10))) {
                return 'CMT/ CCCD chỉ bao gồm số'
            }
        }
    } else {
        return 'CMT/ CCCD phải có 9/12 chữ số'
    }
    return 'Correct';
}

/**
 * @param {} myphone Xâu chứa SDT cần validate
 * @returns Message Kết quả validate
 *  Nguyễn Hùng 18/07
 */
CommonFn.validPhoneNumber = myphone => {
    if (myphone.length == 0) return 'Vui lòng nhập vào trường này';
    if (myphone.length == 10) {
        if (isNaN(myphone)) {
            return "SDT không chứa kí tự đặc biệt";
        } else {
            return 'Correct';
        }
    }
    return "SDT có 10 chữ số";
}