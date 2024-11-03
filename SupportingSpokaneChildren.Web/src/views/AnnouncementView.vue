<template>
  <v-container>
    <v-card>
      <v-sheet color="primary" class="pb-2">
        <v-card-title>
          {{ announcement.title }}
        </v-card-title>
        <v-card-subtitle>
          {{ announcement.datePosted?.toLocaleDateString() }} &nbsp;
          {{ announcement.datePosted?.toLocaleTimeString() }}
        </v-card-subtitle>
      </v-sheet>
      <v-card-title> Description: </v-card-title>
      <v-card-text>
        <p>{{ announcement.description }}</p>
      </v-card-text>
      <v-img
        v-if="announcement.imageUri"
        class="mx-auto mt-2 mb-5"
        :width="400"
        :src="announcement.imageUri"
        cover
      />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { AnnouncementViewModel } from "@/viewmodels.g";
const props = defineProps<{
  id: string;
}>();

const announcement = new AnnouncementViewModel();
announcement.$load(props.id);
</script>
