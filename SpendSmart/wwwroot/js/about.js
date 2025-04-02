document.querySelectorAll('.circle').forEach(circle => {
    circle.addEventListener('click', function () {
        const title = this.getAttribute('data-title');
        const content = getContent(title);

        document.querySelector('.popup-title').textContent = title;
        document.querySelector('.popup-content').textContent = content;
        document.querySelector('#popup').style.display = 'block';
    });
});

document.querySelector('.popup-close').addEventListener('click', function () {
    document.querySelector('#popup').style.display = 'none';
});

function getContent(title) {
    switch (title) {
        case "Welcome to SpendSmart!":
            return "Welcome to SpendSmart! Manage your expenses efficiently with our user-friendly platform.";
        case "Our Mission":
            return "Our mission is to empower individuals to take control of their financial future through smart spending.";
        case "Features":
            return "SpendSmart offers expense tracking, budget management, and financial insights to keep you on track.";
        case "Our Vision":
            return "Our vision is to create a financially literate society where everyone can achieve their goals.";
        case "Get In Touch":
            return "Contact us at support@spendsmart.com for more information and support.";
        default:
            return "Content not available.";
    }
}
