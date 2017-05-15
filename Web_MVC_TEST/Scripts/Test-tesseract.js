$(document).ready(function () {
    $("#getChinese").click(function () {
        var objChinese = document.getElementById("up_img_WU_FILE_0");
        var ChiImageName = "";
        var ChiImageLen = objChinese.files.length;      

        if (ChiImageLen > 0) {
            for (var i = 0; i < ChiImageLen; i++) {
                ChiImageName = objChinese.files[i].name;
                myChiImage = "../Uploads/" + ChiImageName;

                Tesseract.recognize(myChiImage, {
                    lang: 'chi_sim',
                    tessedit_char_blacklist: 'e'
                })
                     .then(function (result) {
                         //console.log(result)                      
                         $("#ChiTextArea").val(result.text);
                         var blob = new Blob([result.text], { type: "text/plain;charset=utf-8" });
                         saveAs(blob, ChiImageName+".txt");
                     })
            }

        }
    });


    $("#getEnglish").click(function () {
        var objEnglish = document.getElementById("up_img_WU_FILE_1");
        var EngImageName = "";
        var EngImageLen = objEnglish.files.length;

        if (EngImageLen > 0) {
            for (var i = 0; i < EngImageLen; i++) {
                EngImageName = objEnglish.files[i].name;
                myEngImage = "../Uploads/" + EngImageName;

                Tesseract.recognize(myEngImage)
                           .then(function (result) {
                               // console.log(result)
                               $("#EngTextArea").val(result.text);
                               var blob = new Blob([result.text], { type: "text/plain;charset=utf-8" });
                               saveAs(blob, EngImageName + ".txt");
                           })
            }
        }
    });

});

