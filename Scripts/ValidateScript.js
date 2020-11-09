document.addEventListener("DOMContentLoaded", function () {
    var elements = document.getElementsByTagName("input");
    var elements1 = document.getElementsByTagName("textarea");

    for (var i = 0; i < elements1.length; i++) {
        elements1[i].oninvalid = function (e) {
            e.target.setCustomValidity("");
            if (!e.target.validity.valid) {
                e.target.setCustomValidity("Thêm mô tả");
            }
        };
        elements1[i].oninput = function (e) {
            e.target.setCustomValidity("");
        };
    }

    for (var i = 0; i < elements.length; i++) {
        elements[i].oninvalid = function (e) {
            e.target.setCustomValidity("");
            if (!e.target.validity.valid) {
                e.target.setCustomValidity("Bạn không được để trống trường này");
            }
        };
        elements[i].oninput = function (e) {
            e.target.setCustomValidity("");
        };
    }
})

$('input').addEventListener('keyup', function (event) {
    if (event.keyCode <=57 && event.keyCode>=48) {
        back(this);
    }
});

function back(d) {
    var value = d.value;
    d.value = value.substr(0, value.length - 1);
}