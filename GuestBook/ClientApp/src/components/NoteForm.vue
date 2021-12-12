<template>
  <form @submit.stop.prevent>
    <h4>Add post</h4>
    <my-input v-focus v-model="note.email" type="email" placeholder="Email"/>
    <my-input v-model="note.name" type="text" placeholder="Your name"/>
    <my-input v-model="note.text" type="text" placeholder="Text"/>
    <my-button style="align-self: flex-end;   margin-top: 15px;" @click="createNote">Add</my-button>
  </form>
</template>

<script>

export default {
  name: "NoteForm",
  data(){
    return {
      note: {
        email: '',
        name: '',
        text: '',
      }
    }
  },
  methods:{
    createNote(){
      this.note.id = Date.now();
      this.$emit('create', this.note);
      this.note = {
        email: '',
        name: '',
        text: '',
      }
    }
  },
}
</script>

<style scoped>
form{
  display: flex;
  flex-direction: column;
}


</style>