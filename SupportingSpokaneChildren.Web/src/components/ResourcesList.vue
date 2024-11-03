<template>
  <v-card>
    <v-sheet color="primary">
      <v-card-title>Resources</v-card-title>
    </v-sheet>
    <v-list v-model:opened="open">
      <v-list-group v-for="category in resourceCategories.$items" :key="category.$stableId">
        <template #activator="{ props }">
          <v-list-item v-bind="props" :title="category.categoryName!" />
        </template>
        <!-- Filter resources based on matching resourceCategoryId -->
        <v-list-item v-for="resource in filteredResources(category.resourceCategoryId!)" :key="resource.$stableId"
          :title="resource.name!" :to="`/resourceview/${resource.resourceId}`">
        </v-list-item>
      </v-list-group>
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
import {
  ResourceCategoryListViewModel,
  ResourceListViewModel,
} from "@/viewmodels.g";

const open = ref([]);
const resourceCategories = new ResourceCategoryListViewModel();
resourceCategories.$params.orderBy = "CategoryName";
resourceCategories.$load();

const resources = new ResourceListViewModel();
resources.$load();

// Function to filter resources by resourceCategoryId
function filteredResources(resourceCategoryId: string) {
  console.log("RCID: ", resourceCategoryId);
  return resources.$items.filter(
    (resource) => resource.resourceCategoryId === resourceCategoryId,
  );
}
</script>
