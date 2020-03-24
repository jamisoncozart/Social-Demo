$(document).ready(function() {
  $("div.postDiv").on("click", ".postScore", function() {
    let clickedId = $(this).attr("id");
    console.log($("#1").value);
  })
})