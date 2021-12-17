import { deleteNote, updateNote } from "../api/noteApi"

export function createNoteElement(id, obj) {
    const noteWrap = document.createElement('div')
    noteWrap.classList.add('note-wrap')

    //#region Title
    const titleElement = document.createElement('input')
    titleElement.classList.add('title')
    titleElement.placeholder = 'عنوان'
    titleElement.maxLength = 21
    titleElement.value = obj.title
    titleElement.addEventListener('change', (e) => {
        obj = {
            id: id,
            title: e.target.value,
            description: obj.description
        }
        console.log(obj);
        updateNote(obj)
    })
        //#endregion

    //#region Note
    const noteElement = document.createElement('textarea')
    noteElement.classList.add('note')
    noteElement.placeholder = 'یادداشت'
    noteElement.value = obj.description
    noteElement.addEventListener('change', (e) => {
        obj = {
            id: id,
            title: obj.title,
            description: e.target.value
        }
        console.log(obj);
        updateNote(obj)
    })
        //#endregion

    const closeElement = document.createElement('i')
    closeElement.classList.add('close-btn')
    closeElement.classList.add('fas')
    closeElement.classList.add('fa-close')
    closeElement.addEventListener('click', (e) => {
        deleteNote(id)
        noteWrap.remove()
    })

    noteWrap.appendChild(titleElement)
    noteWrap.appendChild(noteElement)
    noteWrap.appendChild(closeElement)

    return noteWrap
}