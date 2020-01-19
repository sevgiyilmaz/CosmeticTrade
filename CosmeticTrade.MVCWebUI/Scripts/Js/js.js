$(document).ready(function(){
    $("#btn-search").click(function(){
        $("#searchrow").css("display","block")
        $("#btn-search").css("display","none")
        $("#searchtext").focus();
    });
    $("#searchtext").focusout(function(){
        $("#searchrow").css("display","none")
        $("#btn-search").css("display","block")
    });



    $("#like").click(function(){
        $("#like").css("font-size","45px")
        $("#dislike").css("font-size","30px")

        $("#like").addClass("text-success")
        $("#like").removeClass("text-secondary")

        $("#dislike").addClass("text-secondary")
        $("#dislike").removeClass("text-danger")

        $("#likevalue").val("true")
   });
   $("#dislike").click(function(){
        $("#dislike").css("font-size","45px")
        $("#like").css("font-size","30px")
    
        $("#dislike").addClass("text-danger")
        $("#dislike").removeClass("text-secondary")

        $("#like").addClass("text-secondary")
        $("#like").removeClass("text-success")

        $("#likevalue").val("false")
   });
   if($("#commantaryline").val()==0){
        $("#comment").css("display","none")
        $("#btncommentsubmit").css("display","none")
   }
    else{
        $("#commentfirst").css("display","none")
    }
     $("#firstcommentlink").click(function(){
        $("#commentfirst").css("display","none")
        $("#comment").css("display","block")
        $("#btncommentsubmit").css("display","block")
    })

    bsCustomFileInput.init()
});

function ImageShow(e) {
    $("#productimgshow").attr("src", $(e).attr("src"));
}

function DeleteImage(e,id) {
    e.parentNode.style.opacity = "0.2";
    var value = $("#ImageId").val()
    $("#ImageId").val(value+","+id)
}

