<template>
  <v-container>
    <v-card>
      <v-sheet color="primary" class="pb-2">
        <v-card-title>
          {{ resource.name }}
        </v-card-title>
        <v-card-subtitle>
          {{ resource.resourceCategory?.categoryName }}
        </v-card-subtitle>
      </v-sheet>
      <div v-if="resource.email">
        <v-card-title> Email: </v-card-title>
        <v-card-text>
          <p>{{ resource.email }}</p>
        </v-card-text>
      </div>
      <div v-if="resource.address">
        <v-card-title> Address: </v-card-title>
        <v-card-text>
          <p>{{ resource.address }}</p>
        </v-card-text>
      </div>
      <div v-if="resource.phone">
        <v-card-title> Phone: </v-card-title>
        <v-card-text>
          <p>{{ resource.phone }}</p>
        </v-card-text>
      </div>
      <div v-if="resource.website">
        <v-card-title> Website: </v-card-title>
        <v-card-text>
          <p>{{ resource.website }}</p>
        </v-card-text>
      </div>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { ResourceViewModel } from "@/viewmodels.g";
const props = defineProps<{
  id: string;
}>();

const resource = new ResourceViewModel();
resource.$load(props.id);
</script>
