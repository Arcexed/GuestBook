<template>
  <h1>Page with notes</h1>
  <my-input v-focus v-model="searchQuery" placeholder="Find..."/>
  <div class="app__btns">
    <my-button @click="dialogVisible=true">Create Note</my-button>
    <my-select v-model="selectedSort" :options="sortOptions"/>
  </div>
  <my-dialog v-model:show="dialogVisible">
    <note-form @create="createNote"/>
  </my-dialog>
  <note-list :notes="sortedAndSearchedNotes" @remove="removeNote" v-if="!isNoteLoading"/>
  <div v-else>Loading...</div>
</template>

<script>

import axios from "axios";
import NoteList from "@/components/NoteList";
import NoteForm from "@/components/NoteForm";
export default {
  name: "NotesPage",
  components: {NoteList, NoteForm},
  data(){
    return {
      notes: [],
      dialogVisible: false,
      isNoteLoading: false,
      selectedSort: '',
      searchQuery: '',
      sortOptions: [
        {value: 'name', name: 'By name'},
        {value: 'text', name: 'By text'},
      ]
    }
  },
  methods: {
    async createNote(note){
      const response = await axios.post('http://localhost:5000/api/v1/note', {
        name: note.name,
        email: note.email,
        text: note.text,
      })
      console.log(response)
      await this.fetchNotes();
      this.dialogVisible = false;
    },
    removeNote(note){
      this.note = this.note.filter(d=>d.id!==note.id)
    },
    async fetchNotes(){
      try{
        const response = await axios.get('http://localhost:5000/api/v1/note')
        this.notes = response.data;
        this.isNoteLoading = false;
      }
      catch (ex){
        alert('error');
      }
    },
  },
  mounted() {
    this.fetchNotes();
  },
  computed: {
    sortedNotes(){
      return [...this.notes].sort((post1,post2) => post1[this.selectedSort]?.localeCompare(post2[this.selectedSort]));
    },
    sortedAndSearchedNotes(){
      return this.sortedNotes.filter(post => post.text.includes(this.searchQuery))
    }
  },
}
</script>

<style>

.app__btns{
  display: flex;
  margin: 15px 0;
  justify-content: space-between;
}
.page__wrapper{
  display: flex;
  margin-top: 15px;
}
.page{
  border: 1px solid black;
  padding: 10px;
}
.current-page{
  border: 2px solid teal;
}
.observer{
  height: 30px;

}
</style>