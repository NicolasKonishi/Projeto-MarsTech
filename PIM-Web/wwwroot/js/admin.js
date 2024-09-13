document.getElementById('adicionar-usuario-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    const nome = document.getElementById('nome-adicionar').value;
    const email = document.getElementById('email-adicionar').value;

    const alertMessage = document.getElementById('alert-message-adicionar');
    const alertBox = document.getElementById('custom-alert-adicionar');

    try {
        const response = await fetch('https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/Questionario', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ nome, email })
        });

        if (response.ok) {
            alertMessage.textContent = 'Usuário adicionado com sucesso!';
        } else {
            alertMessage.textContent = 'Erro ao adicionar usuário.';
        }
    } catch (error) {
        alertMessage.textContent = 'Erro ao adicionar usuário.';
        console.error('Erro:', error);
    }

    showAlert('custom-alert-adicionar');
});

document.getElementById('editar-usuario-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    const id = document.getElementById('id-editar').value;
    const nome = document.getElementById('nome-editar').value;
    const email = document.getElementById('email-editar').value;

    const alertMessage = document.getElementById('alert-message-editar');
    const alertBox = document.getElementById('custom-alert-editar');

    try {
        const response = await fetch(`https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/Questionario/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ nome, email })
        });

        if (response.ok) {
            alertMessage.textContent = 'Usuário editado com sucesso!';
        } else {
            alertMessage.textContent = 'Erro ao editar usuário.';
        }
    } catch (error) {
        alertMessage.textContent = 'Erro ao editar usuário.';
        console.error('Erro:', error);
    }

    showAlert('custom-alert-editar');
});

document.getElementById('excluir-usuario-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    const id = document.getElementById('id-excluir').value;

    const alertMessage = document.getElementById('alert-message-excluir');
    const alertBox = document.getElementById('custom-alert-excluir');

    try {
        const response = await fetch(`https://marsapi-b9gbhef8gxfkf5fp.brazilsouth-01.azurewebsites.net/api/Questionario/${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            alertMessage.textContent = 'Usuário excluído com sucesso!';
        } else {
            alertMessage.textContent = 'Erro ao excluir usuário.';
        }
    } catch (error) {
        alertMessage.textContent = 'Erro ao excluir usuário.';
        console.error('Erro:', error);
    }

    showAlert('custom-alert-excluir');
});

function showAlert(alertId) {
    const alertBox = document.getElementById(alertId);
    alertBox.style.display = 'block';
    setTimeout(() => {
        alertBox.style.display = 'none';
    }, 3000);
}