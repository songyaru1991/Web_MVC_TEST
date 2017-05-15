$(".js_upFile").uploadView({
    uploadBox: '.js_uploadBox',//设置上传框容器
    showBox: '.js_showBox',//设置显示预览图片的容器
    width: 100, //预览图片的宽度，单位px
    height: 100, //预览图片的高度，单位px
    allowType: ["gif", "jpeg", "jpg", "bmp", "png"], //允许上传图片的类型
    maxSize: 2, //允许上传图片的最大尺寸，单位M
    success: function (e) {
        $(".js_uploadText").text('更改');
        alert('图片上传成功');
    }
});