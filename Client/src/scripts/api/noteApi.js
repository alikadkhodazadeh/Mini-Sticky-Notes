const toastr = require('toastr')
toastr.options.rtl = true;

export function getNotes() {
    return fetch('https://localhost:7212/Api/Notes')
        .then(res => {
            return res.json()
        })
        .catch(err => {
            toastr.error('اطلاعات از سمت سرور دریافت نشد','خطا')
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
    .catch(err=>{
        toastr.error('آیتمی ایجاد نشد','خطا')
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
    .catch(err=>{
        toastr.error('خطا','آیتم مورد نظر بروزرسانی نشد.')
    })
}

export function deleteNote(id){
    fetch(`https://localhost:7212/Api/Notes/${id}`,{method: 'DELETE'})
}