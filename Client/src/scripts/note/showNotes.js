import { deleteNote, updateNote } from "../api/noteApi";

export function createNoteElement(id, obj) {
    const noteElement = document.createElement('textarea')
    noteElement.classList.add('note')
    noteElement.value = obj.description
    noteElement.addEventListener('input', (e) => {
        const note = {
            id: id,
            title: obj.title,
            description: noteElement.value
        }
        updateNote(note)
    })
    noteElement.addEventListener('dblclick', (e) => {
        deleteNote(id)
        e.target.remove()
    })
    return noteElement
}