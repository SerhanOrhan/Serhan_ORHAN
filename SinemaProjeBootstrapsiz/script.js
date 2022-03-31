$(document).ready(function () {


    let sliderIndex = 0;
    let sliders = $(".slide").toArray();

    let x = document.querySelector(".navbar-kontrol");
    $(".navbar-toggle img").click(function () {
        // $(".navbar-kontrol").css("display","block");
        if (x.style.display == "none") {
            x.style.display = "block"
        } else {
            x.style.display = "none"
        }
    })

    $("#prevSlide").click(function () {
        if (sliderIndex == 0) {
            sliderIndex = sliders.length;
        }
        slider(--sliderIndex)
    })
    $("#nextSlide").click(function () {
        if (sliderIndex == sliders.length - 1) {
            sliderIndex = -1;
        }
        slider(++sliderIndex)
    })
    function slider(n) {
        for (let i = 0; i < sliders.length; i++) {
            sliders[i].style.display = "none";
        }
        $(".slide").eq(n).fadeTo(1000, 0.9)
    }

    $(".card").click(function () {
        $(".main-popup").css("display", "block");
    })

    $(".main-popup").click(function () {
        $(".main-popup").css("display", "none");
    })

    slider(sliderIndex);
})
