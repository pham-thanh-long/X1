// Scroll Logo
ScrollTrigger.create({
    animation: gsap.from(".logo", {
        y: "50vh",
        scale: 6,
        yPercent: -50,
    }),
    scrub: true,
    trigger: ".content",
    start: "top bottom",
    endTrigger: ".content",
    end: "top center",
});

//Wave Music player
const musicPlayer = document.getElementById('musicPlayer');
let wave = document.getElementsByClassName('wave')[0];

musicPlayer.addEventListener('play', () => {
    wave.classList.add('active2');
});

musicPlayer.addEventListener('pause', () => {
    if (musicPlayer.paused || musicPlayer.currentTime <= 0 || musicPlayer.duration < 0) {
        wave.classList.remove('active2');
    }
});