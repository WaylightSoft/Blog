$(document).ready(function()
{
    $(".square")
    .css(
        {"width":$(".square").height()});
});

$( window ).resize(function() {
    $(".square")
    .css(
        {"width":$(".square").height()});
});
