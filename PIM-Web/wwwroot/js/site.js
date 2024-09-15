document.addEventListener("DOMContentLoaded", () => {
    const buttons = document.querySelectorAll(".carousel-button");
    const carouselImages = document.querySelector(".carousel-images");
    const totalItems = document.querySelectorAll(".carousel-item1").length;
    const infoTitle = document.getElementById("info-title");
    const infoDescription = document.getElementById("info-description");

    const infoData = [
        {
            title: "Vida em Marte",
            description:
                "Oferece uma visão artística da possibilidade de vida no planeta vermelho. A obra apresenta uma interpretação imaginativa dos tipos de organismos que poderiam existir nas condições extremas de Marte, explorando conceitos de biologia astrobiológica e adaptações a ambientes inóspitos.",
            backgroundImage: "./css/images/obra1-bg.png",
        },
        {
            title: "A Primeira Colônia",
            description:
                "Retrata a instalação pioneira dos primeiros colonizadores humanos em Marte. A arte explora a arquitetura futurística e o design das habitações e instalações que permitiriam a sobrevivência e o desenvolvimento de uma comunidade em um ambiente alienígena.",
            backgroundImage: "./css/images/obra2-bg.png",
        },
        {
            title: "O Enigma Vermelho",
            description:
                "Esta obra explora a cor marcante de Marte, causada pela oxidação do ferro em sua superfície, criando um vasto deserto de poeira vermelha. O Enigma Vermelho simboliza mistério e a busca por compreender o desconhecido.",
            backgroundImage: "./css/images/obra3-bg.png",
        },
        {
            title: "Sobrevivência Extrema",
            description:
                "Esta obra retrata os desafios de viver em Marte, um ambiente árido e inóspito. Com temperaturas extremas e uma atmosfera imprópria para a vida humana, a obra nos faz refletir sobre a viabilidade de sobreviver em Marte e a necessidade de inovação para superar esses obstáculos.",
            backgroundImage: "./css/images/obra4-bg.png",
        },
    ];

    let isDragging = false;
    let startPos = 0;
    let currentTranslate = 0;
    let prevTranslate = 0;
    let currentIndex = 0;
    const threshold = 50;

    function showImage(index) {
        if (index >= totalItems) {
            currentIndex = 0;
        } else if (index < 0) {
            currentIndex = totalItems - 1;
        } else {
            currentIndex = index;
        }
        carouselImages.style.transition = 'transform 0.5s ease';
        carouselImages.style.transform = `translateX(-${currentIndex * 100}%)`;
        updateButtons();
        updateInfo();
    }

    function updateButtons() {
        buttons.forEach((button, index) => {
            if (index === currentIndex) {
                button.classList.add("selected");
            } else {
                button.classList.remove("selected");
            }
        });
    }

    function updateInfo() {
        const { title, description, backgroundImage } = infoData[currentIndex];
        infoTitle.textContent = title;
        infoDescription.textContent = description;
        document.querySelector(
            ".image-carousel-container"
        ).style.backgroundImage = `url(${backgroundImage})`;
    }

    buttons.forEach((button, index) => {
        button.addEventListener("click", () => {
            showImage(index);
        });
    });

    showImage(currentIndex);

    const carouselWidth = carouselImages.clientWidth;

    carouselImages.addEventListener('touchstart', touchStart);
    carouselImages.addEventListener('touchmove', touchMove);
    carouselImages.addEventListener('touchend', touchEnd);

    function touchStart(event) {
        isDragging = true;
        startPos = event.touches[0].clientX;
        carouselImages.style.transition = 'none';
        prevTranslate = -currentIndex * carouselWidth;
    }

    function touchMove(event) {
        if (isDragging) {
            const currentPosition = event.touches[0].clientX;
            currentTranslate = prevTranslate + currentPosition - startPos;
            carouselImages.style.transform = `translateX(${currentTranslate}px)`;
        }
    }

    function touchEnd() {
        isDragging = false;

        const movedBy = currentTranslate - prevTranslate;

        if (movedBy < -threshold && currentIndex < totalItems - 1) {
            currentIndex += 1;
        } else if (movedBy > threshold && currentIndex > 0) {
            currentIndex -= 1;
        }

        showImage(currentIndex);
    }
});

async function fetchValidComment(displayedComments) {
    try {
        let validComment = null;

        while (!validComment) {
            const response = await fetch("https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/questionario/random-comment");
            const commentData = await response.json();

            if (commentData && commentData.email && commentData.email.includes('@')) {
                const email = commentData.email;

                if (!displayedComments.has(email)) {
                    validComment = commentData;
                } else {
                    console.log('Comentário repetido, buscando outro...');
                }
            } else {
                console.log('Email inválido ou ausente, buscando outro comentário...');
            }
        }

        return validComment;
    } catch (error) {
        console.error('Erro ao buscar comentário válido:', error);
        return null;
    }
}

async function fetchRandomComments() {
    try {
        const displayedComments = new Set();

        const commentSection = document.querySelector(".testimonials-quotes");
        commentSection.innerHTML = "";

        for (let i = 0; i < 2; i++) {
            const commentData = await fetchValidComment(displayedComments);

            if (commentData && commentData.comentario && commentData.email) {
                const email = commentData.email;
                let displayEmail = email.split('@')[0] + '@****';

                displayedComments.add(email);

                const quoteElement = document.createElement("div");
                quoteElement.className = "quote";
                quoteElement.innerHTML = `
                    <p>"${commentData.comentario}"</p>
                    <span class="quote-author">- ${displayEmail}</span>
                `;
                commentSection.appendChild(quoteElement);
            } else {
                console.error('Dados de comentário inválidos:', commentData);
            }
        }
    } catch (error) {
        console.error('Erro ao buscar comentários:', error);
    }
}
fetchRandomComments();


document.addEventListener('DOMContentLoaded', function () {
    fetchAverageExhibitions();
    fetchAverageSatisfaction();
});

async function fetchAverageExhibitions() {
    try {
        const response = await fetch('https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/questionario/average-exhibitions');
        if (!response.ok) {
            throw new Error('Erro ao buscar a média de exposições.');
        }

        const averageExhibitions = await response.json();
        document.querySelector('.metrics-container .metric:nth-child(2) .percentage').textContent = averageExhibitions.toFixed(1) || '0.0';

    } catch (error) {
        console.error('Erro:', error);
        document.querySelector('.metrics-container .metric:nth-child(2) .percentage').textContent = 'Erro ao buscar dados';
    }
}

async function fetchAverageSatisfaction() {
    try {
        const response = await fetch('https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/Questionario/average-satisfaction');
        if (!response.ok) {
            throw new Error('Erro ao buscar a média de satisfação.');
        }

        const averageSatisfaction = await response.json();
        document.querySelector('.metrics-container .metric:nth-child(1) .percentage').textContent = averageSatisfaction.toFixed(1) || '0.0';

    } catch (error) {
        console.error('Erro:', error);
        document.querySelector('.metrics-container .metric:nth-child(1) .percentage').textContent = 'Erro ao buscar dados';
    }
}

document.getElementById("submit-form").addEventListener("click", async function () {
    const visitante = {
        satisfacaoGeral: document.getElementById("satisfaction-1").value,
        qualidadeExposicao: document.getElementById("satisfaction-2").value,
        comentario: document.getElementById("user-message").value,
        email: document.getElementById("user-email-input").value
    };

    const alertMessage = document.getElementById("alert-message");
    const alertBox = document.getElementById("custom-alert");

    try {
        const response = await fetch("https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/Questionario", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(visitante)
        });

        if (response.ok) {
            alertMessage.textContent = "Obrigado por enviar sua opinião!";
        } else {
            alertMessage.textContent = "Erro ao enviar sua opinião.";
        }
    } catch (error) {
        alertMessage.textContent = "Erro ao enviar sua opinião.";
        console.error("Erro:", error);
    }

    showAlert();
});

function showAlert() {
    const alertBox = document.getElementById("custom-alert");

    alertBox.classList.remove("show", "fade-out");
    void alertBox.offsetWidth; 
    alertBox.classList.add("show");

    setTimeout(() => {
        alertBox.classList.add("fade-out");
        setTimeout(() => alertBox.classList.add("hidden"), 500);
    }, 1000);
}
document.getElementById('user-email-input').addEventListener('keydown', function (event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        console.log('Enter pressionado, mas não permitido.');
    }
});


document.getElementById("loginForm").addEventListener("submit", function (event) {
    event.preventDefault();

    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var errorMessage = document.getElementById("error-message");

    var correctUsername = "adm123";
    var correctPassword = "Mars123";

    if (username === correctUsername && password === correctPassword) {
        errorMessage.textContent = ""; 
        window.location.href = "/Admin"; 
    } else {
        errorMessage.textContent = "Usuário ou senha inválidos.";
    }
});
