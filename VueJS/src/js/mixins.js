export const CommonFn = {
    created() {
        console.log("CommonFn's activated")
    },
    methods: {
        formatData(data) {
            let datax = data + '';
            if (datax.includes('Z')) {
                console.log("datax", datax)
                return this.formatDateYMD(data)
            }
            return data;
        },


        /**
         * @param {} thisdate Xâu javascript date
         * @returns Xâu ở dạng yyyy-MM-dd
         *  Nguyễn Hùng 18/07
         */
        formatDateYMD(thisdate) {
            let date = new Date(thisdate);
            return date.getFullYear() + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + ("0" + date.getDate()).slice(-2);
        },

        /**
         * @param {} thisdate Xâu javascript date
         * @returns Xâu ở dạng yyyy-MM-dd
         *  Nguyễn Hùng 18/07
         */
        formatGenderName(gender) {
            if (gender === 0) return 'Nữ';
            else if (gender === 1) return 'Nam';
            else return 'Khác';
        },

        /**
         * @param {} thisdate Xâu javascript date
         * @returns Xâu ở dạng dd/MM/yyyy
         */
        formatDateDMY(thisdate) {
            let date = new Date(thisdate);
            return ("0" + date.getDate()).slice(-2) + '/' + ("0" + (date.getMonth() + 1)).slice(-2) + '/' + date.getFullYear();
        },

        /**
         * 
         * @param {} myinput  xâu bất kỳ
         * @returns Xâu số (dấu ngăn . cách phần nghìn )
         */
        formatMoney(myinput) {
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
        },

        /**
         * @param {} myinput Xâu  input bất kỳ
         * @returns Xâu chỉ chứa số
         *  Nguyễn Hùng 18/07
         */
        formatNumber(myinput) {
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
        },

        /**
         * 
         * @param {*} input xâu input cần validate
         * @param {*} dataType kiểu dữ liệu cần validate
         * @returns 
         */
        validateInputFormat(input, dataType) {
            switch (dataType) {
                case 'HumanName':
                    return this.validName(input);
                case 'Email':
                    return this.validEmail(input);
                case 'PhoneNumber':
                    return this.validPhoneNumber(input);
                case 'IdentityNumber':
                    return this.validIdentity(input);
                default:
                    if (input.length == 0)
                        return 'Vui lòng nhập vào trường này';
                    return 'Correct';
            }
        },

        /**
         * @param {} myname Xâu chứa tên cần validate
         * @returns Message Kết quả validate
         *  Nguyễn Hùng 18/07
         */
        validName(myname) {
            if (myname.length == 0) return 'Vui lòng nhập vào trường này';
            for (var i = 0; i < myname.length; i++) {
                if (!isNaN(parseInt(myname[i], 10))) {
                    return "Tên không được có chữ số";
                }
            }
            return 'Correct';
        },

        /**
         * @param {} myemail Xâu chứa email cần validate
         * @returns Message Kết quả validate
         *  Nguyễn Hùng 18/07
         */
        validEmail(myemail) {
            if (myemail.length == 0) return 'Vui lòng nhập vào trường này';
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            // console.log(myemail);
            if (re.test(String(myemail).toLowerCase()) == true) return true;
            return false;
        },

        /**
         * @param {} myid Xâu chứa CMTND/CCCD cần validate
         * @returns Message Kết quả validate
         *  Nguyễn Hùng 18/07
         */
        validIdentity(myid) {
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
        },

        /**
         * @param {} myphone Xâu chứa SDT cần validate
         * @returns Message Kết quả validate
         *  Nguyễn Hùng 18/07
         */
        validPhoneNumber(myphone) {
            if (myphone.length == 0) return 'Vui lòng nhập vào trường này';
            if (myphone.length == 10) {
                if (isNaN(myphone)) {
                    return "SDT không chứa kí tự đặc biệt";
                } else {
                    return 'Correct';
                }
            }
            return "SDT có 10 chữ số";
        },
    },
}