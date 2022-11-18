function activePage(id){
    let icons = $('.nav-item');
    icons.removeClass('active');

    let currentIcon = $('#' + id);

    currentIcon.addClass("active");
}