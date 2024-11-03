<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="6">
        <AnnouncementsList />
        <ResourcesList v-if="!isMobile" />
      </v-col>
      <v-col cols="12" md="6">
        <EventsList />
      </v-col>
      <v-col v-if="isMobile" cols="12" md="6">
        <ResourcesList />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { useDisplay } from 'vuetify/lib/framework.mjs';

useTitle("Home");
const display = ref(useDisplay());

const isMobile = computed<boolean>(() => {
  switch (display.value.name) {
    case 'xs': return true;
  }
  return false;
})
</script>
