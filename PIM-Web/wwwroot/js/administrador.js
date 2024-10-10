function toggleMenu() {
    var menu = document.getElementById("myLinks");
    menu.classList.toggle("active");
}

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('adicionar-usuario-form').addEventListener('submit', async function (event) {
        event.preventDefault();

        const nome = document.getElementById('nome-adicionar').value;
        const email = document.getElementById('email-adicionar').value;
        const satisfacaoGeral = document.getElementById('satisfacao-adicionar').value;
        const qualidadeExposicao = document.getElementById('qualidade-adicionar').value;
        const comentario = document.getElementById('comentario-adicionar').value;

        const alertMessage = document.getElementById('alert-message-adicionar');
        const alertBox = document.getElementById('custom-alert-adicionar');

        try {
            const response = await fetch('https://localhost:7195/api/Questionario', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    nome,
                    email,
                    satisfacaoGeral,
                    qualidadeExposicao,
                    comentario
                })
            });

            if (response.ok) {
                alertMessage.textContent = 'Avaliação adicionada com sucesso!';
                loadAvaliacoes();
            } else {
                alertMessage.textContent = 'Erro ao adicionar avaliação.';
            }
        } catch (error) {
            alertMessage.textContent = 'Erro ao adicionar avaliação.';
            console.error('Erro:', error);
        }

        showAlert('custom-alert-adicionar');
    });

    document.getElementById('editar-usuario-form').addEventListener('submit', async function (event) {
        event.preventDefault();

        const id = document.getElementById('id-editar').value;
        const satisfacaoGeral = document.getElementById('satisfacao-editar').value;
        const qualidadeExposicao = document.getElementById('qualidade-editar').value;
        const comentario = document.getElementById('comentario-editar').value;
        const email = document.getElementById('email-editar').value;

        const response = await fetch(`https://localhost:7195/api/Questionario/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id,
                satisfacaoGeral,
                qualidadeExposicao,
                comentario,
                email
            })
        });

        const alertMessage = document.getElementById('alert-message-editar');
        const alertBox = document.getElementById('custom-alert-editar');

        if (response.ok) {
            alertMessage.textContent = 'Avaliação editada com sucesso!';
            loadAvaliacoes();
        } else {
            alertMessage.textContent = 'Erro ao editar avaliação.';
        }

        showAlert('custom-alert-editar');
    });

    document.getElementById('excluir-usuario-form').addEventListener('submit', async function (event) {
        event.preventDefault();

        const id = document.getElementById('id-excluir').value;

        const alertMessage = document.getElementById('alert-message-excluir');
        const alertBox = document.getElementById('custom-alert-excluir');

        try {
            const response = await fetch(`https://localhost:7195/api/Questionario/${id}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alertMessage.textContent = 'Avaliação excluída com sucesso!';
                loadAvaliacoes();
            } else {
                alertMessage.textContent = 'Erro ao excluir avaliação.';
            }
        } catch (error) {
            alertMessage.textContent = 'Erro ao excluir avaliação.';
            console.error('Erro:', error);
        }

        showAlert('custom-alert-excluir');
    });

    function showAlert(alertId) {
        document.getElementById(alertId).style.display = 'block';
        setTimeout(() => {
            document.getElementById(alertId).style.display = 'none';
        }, 3000);
    }

   
    async function loadAvaliacoes() {
        const tableBody = document.querySelector('#tabela-avaliacoes tbody');

        try {
            const response = await fetch('https://localhost:7195/api/Questionario');
            const avaliacoes = await response.json();

            tableBody.innerHTML = '';

            avaliacoes.forEach(avaliacao => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${avaliacao.id}</td>
                    <td>${avaliacao.satisfacaoGeral}</td>
                    <td>${avaliacao.qualidadeExposicao}</td>
                    <td>${avaliacao.comentario || 'N/A'}</td>
                    <td>${avaliacao.email}</td>
                `;
                tableBody.appendChild(row);
            });
        } catch (error) {
            console.error('Erro ao carregar avaliações:', error);
        }
    }

    loadAvaliacoes();

 


}
)
;
