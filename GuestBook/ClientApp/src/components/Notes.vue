<template>
  <h1 id="tableLabel">GuestBook</h1>
  <p v-if="!notes"><em>Loading...</em></p>
  <div v-if="notes">
    <form @submit.prevent.stop v-if="visibleAddNotes">
      <input class="input" type="text" placeholder="Name" v-model="name">
      <input class="input" type="text" placeholder="Email" v-model="email">
      <input class="input" type="text" placeholder="Text" v-model="text">
      <button class="btn" @click="createNote">Add</button>
    </form>
    <div class="notes">
      <div class="note" v-for="note in notes" :key="note.id">
        <div class="note__title-client">
          <h1>{{ note.name }}</h1>
          <h1>{{ note.email }}</h1>
        </div>
        <div class="note__text">
          {{ note.text }}
        </div>
        <div class="note__date">
          {{ note.creatingDate }}
        </div>
      </div>
    </div>
  </div>

</template>


<script>
import axios from 'axios'
export default {
  name: "Notes",
  data() {
    return {
      notes: [],
      email: 'Test Email',
      name: 'Test Name',
      text: 'Test Text',
      visibleAddNotes: false,
    }
  },
  methods: {
    getNotes() {
      axios.get('api/v1/note')
          .then((response) => {
            this.notes =  response.data;
          })
          .catch(function (error) {
            alert(error);
          });
    },
    createNote(){
      axios.post('api/v1/note/add',{
        name: this.name,
        email: this.email,
        text: this.text,
      })
          .catch(function (error) {
            alert(error);
          });
    },
  },
  mounted() {
    this.getNotes();
  }
}
</script>

<style scoped>
.notes{
}
.note{
  padding: 50px;
}
</style>