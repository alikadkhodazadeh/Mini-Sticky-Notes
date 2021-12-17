import { v4 as uuidv4 } from 'uuid'

const apiNote = require("./api/noteApi")
const showNotes = require("./note/showNotes")
const toastr = require('toastr')

toastr.options.rtl = true;

const noteContainer = document.querySelector('#container')
const addNoteBtn = document.querySelector('.add-note')

addNoteBtn.addEventListener('click', addNote)


apiNote.getNotes()
    .then(data => {
        data.forEach(item => {
            const noteElement = showNotes.createNoteElement(item.id, item)
            const noteContainer = document.querySelector('#container')
            const addNoteBtn = document.querySelector('.add-note')
            noteContainer.insertBefore(noteElement, addNoteBtn)
        })
    })
    .catch(err=>{
        console.log(err);
    })
function addNote() {
    const note = {
        id: uuidv4(),
        title: '',
        description: ''
    }
    const noteElement = showNotes.createNoteElement(note.id, note)
    noteContainer.insertBefore(noteElement, addNoteBtn)
    apiNote.createNote(note)
}

