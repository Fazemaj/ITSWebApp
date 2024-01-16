// $(document).ready(function () {
//     $('.js--info-section').waypoint(function (direction) {
//         if (direction == "down") {
//             $('nav').addClass('sticky');
//         }
//         else {
//             $('nav').removeClass('sticky');
//         }
//     }, {
//         offset: '63px'
//     })




//     /*Scroll on buttons */
//     $('.js--scroll-to-info').click(function () {
//         $('html, body').animate({ scrollTop: $('.js--info-section').offset().top }, 1000)
//     });






//     /*SMOOTH SCROLLING */

//     // Select all links with hashes
//     $('a[href*="#"]')
//         // Remove links that don't actually link to anything
//         .not('[href="#"]')
//         .not('[href="#0"]')
//         .click(function (event) {
//             // On-page links
//             if (
//                 location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
//                 &&
//                 location.hostname == this.hostname
//             ) {
//                 // Figure out element to scroll to
//                 var target = $(this.hash);
//                 target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
//                 // Does a scroll target exist?
//                 if (target.length) {
//                     // Only prevent default if animation is actually gonna happen
//                     event.preventDefault();
//                     $('html, body').animate({
//                         scrollTop: target.offset().top
//                     }, 1000, function () {
//                         // Callback after animation
//                         // Must change focus!
//                         var $target = $(target);
//                         $target.focus();
//                         if ($target.is(":focus")) { // Checking if the target was focused
//                             return false;
//                         } else {
//                             $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
//                             $target.focus(); // Set focus again
//                         };
//                     });
//                 }
//             }
//         });
// });

let text = document.getElementById('email').innerHTML;
var copiedDiv = document.getElementById('copied');
    const copyContent = async () => {
    await navigator.clipboard.writeText(text);
    copiedDiv.classList.add("animation");
    setTimeout(removeAnime, 1000);
    
    // copiedDiv.style.color = "";
  }   

function removeAnime(){
    copiedDiv.classList.remove("animation");
}



////////////////////////////////////////////////////////////////////////////////////////////////////

file = document.querySelector('#files > input[type="file"]').files[0];

const toBase64 =  file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = reject;
});

var base64File = toBase64(file);
console.log(base64File);