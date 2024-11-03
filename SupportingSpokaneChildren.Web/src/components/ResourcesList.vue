<template>
  <v-card>
    <v-sheet color="primary">
      <v-card-title>Resources</v-card-title>
    </v-sheet>
    <v-list v-model:opened="open">
      <v-list-group v-for="category in resourceCategories.$items" :key="category.$stableId">
        <template v-slot:activator="{ props }">
          <v-list-item v-bind="props" :title="category.categoryName!" />
        </template>
        <!-- <template v-for="resource in " -->
      </v-list-group>
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
import { ResourceCategoryListViewModel } from '@/viewmodels.g';

const open = ref([]);
const resourceCategories = new ResourceCategoryListViewModel();
resourceCategories.$params.orderBy = "CategoryName";
resourceCategories.$load();

</script>