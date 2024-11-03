<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="6">
        <AnnouncementsList />
      </v-col>
      <v-col cols="12" md="6">
        <EventsList />
      </v-col>
      <v-col cols="12" md="6">
        <ResourcesList />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
useTitle("Home");
</script>
