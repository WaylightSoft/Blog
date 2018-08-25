var PageNo=1;
var UserId;
var Nick;

function addTags(item,post)
{
    let tags = $("<div></div>").addClass("row tag-container");
    let Tags=item.Tags;
    console.log(Tags);
    $.each(Tags,function(key,it)
        {
            console.log(key);
            console.log(it);
            let tag=$("<div></div>").addClass("tag");
            tag.append($('<a href=""></a>').text(it.Name).attr("href","Tag/"+it.Id));
            console.log(tag);
            tags.append(tag);
        });
    post.append(tags);            
}
function addPost(item)
{
    // let post= $("div.post")
    //             .add("div")
    //             .addClass("col-sm-12 col-md-12")
    //             ;
    let post = $("<div></div>").addClass("post").addClass("row").addClass("col-sm-12 col-md-12");        
            post.append('<div class="col-sm-3 col-md-3"><div class="row rowforrating">'
            +'<div class="col-sm-6 col-md-6" style="padding-left:0px">Rating<br />'
            +item.Rating+'</div>'
            +'<div class="col-sm-6 col-md-6">Views<br />'
            +item.Views+'</div>'
            +'</div>'
            +'</div>');
            let tandt= $('<div class="col-sm-9 col-md-9">'
            +'<div class="row">'
                +'<div class="post-title col-sm-12 col-md-12">'
                + '<a href="">' + item.Title+'</a>'
                +'</div>'
                +'<hr/>'
            +'</div>');
            addTags(item,tandt);      
            post.append(tandt);
     $(".postFeed").append(post);     
}
function LoadMorePosts()
{
    $.getJSON("api/APIPost/GetCol/"+PageNo+"/0/"+UserId)
          .done(function (arr)
            {
                  console.log(arr);
                  arr.forEach(function (item, i, arr) {
                      let a = item;
                      console.log(a); 
                      addPost(a);
                  })
                  PageNo++;
            });
}
$(document).ready(function()
{
    Nick=document.getElementsByClassName("nickname")[0].outerText;

    $.getJSON("api/APIUser/GetId/"+Nick)
    .done(function(data)
        {
          UserId=data;  
          $.getJSON("api/APIPost/GetCol/"+PageNo+"/0/"+UserId)
          .done(function (arr)
              {
                  console.log(arr);
                  arr.forEach(function (item, i, arr) {
                      let a = item;
                      console.log(a); 
                      addPost(a);
                  });
                  PageNo++;
              });
        });
});
$(".button").click(LoadMorePosts);
