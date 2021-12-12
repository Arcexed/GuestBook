<template>
  <div v-if="notes.length">
    <h3>List of notes</h3>
    <transition-group name="note-list">
      <NoteItem v-for="note in notes" :note="note" :key="note.id" @remove="$emit('remove', note)"/>
    </transition-group>
  </div>
  <h2 style="color: red;" v-else>List is null</h2>
</template>

<script>
import NoteItem from "@/components/NoteItem";
export default {
  name: "NoteList",
  components: {NoteItem},
  props:{
    notes:{
      type: Array,
      required: true,
    },
  }
}
</script>

<style scoped>
.note-list-item{
  display: inline-block;
  margin-right: 10px;
}
.note-list-enter-active,
.note-list-leave-active{
  transition: all 0.4s ease;
}
.note-list-enter-from,
.note-list-leave-to{
  opacity: 0;
  transform: translateX(30px);
}
.note-list-move{
  transition: transform 0.8s ease;
}
</style>