<template>
  <div class="note" :key="note.id">
    <div>
      <div><strong>Id:</strong>{{ note.id }}</div>
      <div><strong>Email:</strong> {{ note.email }}</div>
      <div><strong>Name:</strong> {{ note.name}} </div>
      <div><strong>Text:</strong> {{ note.text}} </div>
      <div><strong>CreatingDateTime:</strong> {{ note.creatingDateTime}} </div>
      <div class="note__btns">
        <my-button @click="$emit('remove', note)">Delete</my-button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    note: {
      type: Object,
      required: true,
    },
  },
  name: "note-item",
};
</script>

<style scoped>
.note {
  padding: 15px;
  border: 2px solid teal;
  margin-top: 15px;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

</style>
