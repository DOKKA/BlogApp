// Write your JavaScript code.
$('#CreatePost').click(function () {
    
    $.post('/api/posts', $('form').serialize(), function (data) {
        console.log(data)
    })
});