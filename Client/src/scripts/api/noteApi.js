export function getNotes() {
    return fetch('https://localhost:7212/Api/Notes')
        .then(res => {
            return res.json()
        })
        .catch(err => {
            console.log(err);
        })
}

export function createNote(obj) {
    fetch('https://localhost:7212/Api/Notes', {
        method: 'POST',
        body: JSON.stringify(obj),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
}

export function updateNote(obj){
    fetch(`https://localhost:7212/Api/Notes/${obj.id}`, {
        method: 'PUT',
        body: JSON.stringify(obj),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
}

export function deleteNote(id){
    fetch(`https://localhost:7212/Api/Notes/${id}`,{method: 'DELETE'})
}