$(function () {
    // Sidebar toggle behavior
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
    });
});



var thispage = "home"

$('.nav-item').on('click', function () {
    thispage = jQuery(this).attr("id");
});