<template>
  <v-container>
    <v-card>
      <v-sheet color="primary" class="pb-2">
        <v-card-title>
          {{ event.eventName }}
        </v-card-title>
        <v-card-subtitle>
          {{ event.dateTime?.toLocaleDateString() }} &nbsp;
          {{ event.dateTime?.toLocaleTimeString() }}
        </v-card-subtitle>
      </v-sheet>
      <div v-if="event.description">
        <v-card-title> Description: </v-card-title>
        <v-card-text>
          <p>{{ event.description }}</p>
        </v-card-text>
      </div>
      <div v-if="event.location">
        <v-card-title> Location: </v-card-title>
        <v-card-text>
          <p>{{ event.location }}</p>
        </v-card-text>
      </div>
      <div v-if="event.link">
        <v-card-title> Link: </v-card-title>
        <v-card-text>
          <p>{{ event.link }}</p>
        </v-card-text>
      </div>
      <v-img
        v-if="event.imageUri"
        class="mx-auto mt-2 mb-5"
        :width="400"
        :src="event.imageUri"
        cover
      />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { EventViewModel } from "@/viewmodels.g";
const props = defineProps<{
  id: string;
}>();

const event = new EventViewModel();
event.$load(props.id);
</script>
