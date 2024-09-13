function adicionarUsuario() {
    const nome = document.getElementById('nome-adicionar').value;
    const email = document.getElementById('email-adicionar').value;

    fetch('https://sua-api.com/adicionarUsuario', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ nome, email })
    })
        .then(response => response.json())
        .then(data => {
            alert('Usuário adicionado com sucesso!');
            console.log(data);
        })
        .catch(error => console.error('Erro:', error));
}

function editarUsuario() {
    const id = document.getElementById('id-editar').value;
    const nome = document.getElementById('nome-editar').value;
    const email = document.getElementById('email-editar').value;

    fetch(`https://sua-api.com/editarUsuario/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ nome, email })
    })
        .then(response => response.json())
        .then(data => {
            alert('Usuário editado com sucesso!');
            console.log(data);
        })
        .catch(error => console.error('Erro:', error));
}

function excluirUsuario() {
    const id = document.getElementById('id-excluir').value;

    fetch(`https://sua-api.com/excluirUsuario/${id}`, {
        method: 'DELETE'
    })
        .then(response => response.json())
        .then(data => {
            alert('Usuário excluído com sucesso!');
            console.log(data);
        })
        .catch(error => console.error('Erro:', error));

ws }