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
            description: "Esta obra explora a cor marcante de Marte, causada pela oxidação do ferro em sua superfície, criando um vasto deserto de poeira vermelha. O Enigma Vermelho simboliza mistério e a busca por compreender o desconhecido.",
            backgroundImage: "./css/images/obra3-bg.png",
        },
        {
            title: "Sobrevivência Extrema",
            description: "Esta obra retrata os desafios de viver em Marte, um ambiente árido e inóspito. Com temperaturas extremas e uma atmosfera imprópria para a vida humana, a obra nos faz refletir sobre a viabilidade de sobreviver em Marte e a necessidade de inovação para superar esses obstáculos.",
            backgroundImage: "./css/images/obra4-bg.png",
        },
    ];
    let currentIndex = 0;

    function showImage(index) {
        if (index >= totalItems) {
            currentIndex = 0;
        } else if (index < 0) {
            currentIndex = totalItems - 1;
        } else {
            currentIndex = index;
        }
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
});

const metrics = {
    overallSatisfaction: 75,
    serviceRating: 90,
    testimonials: [
        {
            text: "O museu é incrível! Adorei a exposição sobre a primeira viagem à Lua.",
            author: "João Silva",
        },
        {
            text: "A experiência foi fantástica, aprendi muito sobre a história da exploração espacial.",
            author: "Maria Oliveira",
        },
    ],
};

async function fetchRandomComments() {
    try {
        const responses = await Promise.all([
            fetch("https://localhost:7195/api/questionario/random-comment"),
            fetch("https://localhost:7195/api/questionario/random-comment")
        ]);

        const data = await Promise.all(responses.map(response => response.json()));

        console.log('Dados retornados da API:', data);

        const commentSection = document.querySelector(".testimonials-quotes");
        commentSection.innerHTML = "";

        data.forEach(commentData => {
            if (commentData && commentData.comentario && commentData.email) {
                const quoteElement = document.createElement("div");
                quoteElement.className = "quote";
                quoteElement.innerHTML = `
                    <p>"${commentData.comentario}"</p>
                    <span class="quote-author">- ${commentData.email}</span>
                `;
                commentSection.appendChild(quoteElement);
            } else {
                console.error('Dados de comentário inválidos:', commentData);
            }
        });
    } catch (error) {
        console.error('Error fetching random comments:', error);
    }
}

fetchRandomComments();


document.addEventListener('DOMContentLoaded', function () {
    fetchAverageExhibitions();
    fetchAverageSatisfaction();
});

async function fetchAverageExhibitions() {
    try {
        const response = await fetch('https://localhost:7195/api/questionario/average-exhibitions');
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
        const response = await fetch('https://localhost:7195/api/Questionario/average-satisfaction');
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
        const response = await fetch("https://localhost:7195/api/Questionario", {
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
        alert("Login bem-sucedido! Bem-vindo, administrador.");
        window.location.href = "/Admin"; 
    } else {
        errorMessage.textContent = "Usuário ou senha inválidos.";
    }
});
