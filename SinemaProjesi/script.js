let sliderIndex=0;
let allSlides=$(".slide").toArray();

    $("#prevSlide").click(function(){
        if (sliderIndex==0) {
            sliderIndex=allSlides.length;
        }
        showSlide(--sliderIndex);
    })
    $("#nextSlide").click(function(){
        if (sliderIndex==allSlides.length-1) {
            sliderIndex=-1;
        }
        showSlide(++sliderIndex);
    })
    $(".card").click(function(e){
        $(".cards-popup").css("display","block");
    })
    $(".close-popup").click(function(){
        $(".cards-popup").css("display","none");
    })

function showSlide(n){
for (let i = 0; i < allSlides.length; i++) {
    allSlides[i].style.display="none";
}
    allSlides[n].style.display="block";
}
showSlide(sliderIndex)