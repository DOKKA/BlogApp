// Write your JavaScript code.
$('#CreatePost').click(function () {
    var PostTitle = $('#PostTitle').val();
    var PostBody = $('#PostBody').val();

    var customer = { PostTitle: PostTitle, PostBody: PostBody };
    $.ajax({
        type: "POST",
        data: JSON.stringify(customer),
        url: '/api/posts',
        contentType: "application/json"
    });

});