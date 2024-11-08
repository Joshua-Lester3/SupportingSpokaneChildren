<template>
  <v-card>
    <v-sheet color="primary">
      <v-card-title>Events</v-card-title>
    </v-sheet>
  </v-card>
  <v-row>
    <v-col cols="auto" class="mx-auto">
      <v-card v-for="event in events.$items" :key="event.$stableId" class="my-5 mx-auto pa-3"
        :to="`/eventview/${event.eventId}`">
        <v-img v-if="event.imageUri" aspect-ratio="auto" :width="230" :src="event.imageUri" cover />
        <v-card-title> {{ event.eventName }}</v-card-title>
        <v-card-subtitle> {{ event.location }}</v-card-subtitle>
        <v-card-subtitle>{{
          `${event.dateTime?.toDateString()} ${event.dateTime?.toLocaleTimeString()}`
        }}</v-card-subtitle>
      </v-card>
    </v-col>
  </v-row>
  <v-pagination v-model="eventsPage" :length="eventsLength" @update:model-value="goto" @prev="movePrev"
    @next="moveNext" />
</template>

<script setup lang="ts">
import { EventListViewModel } from "@/viewmodels.g";
import { Event } from "@/models.g";
import { useDisplay } from "vuetify/lib/framework.mjs";

const display = ref(useDisplay());
const eventsPage = ref(1);
const events = new EventListViewModel();
const eventsPageSize = computed(() => {
  switch (display.value.name) {
    case "xs":
      return 1;
    case "sm":
    case "md":
      return 2;
    case "lg":
      return 3;
    case "xl":
      return 4;
    case "xxl":
      return 5;
  }
});
events.$pageSize = eventsPageSize.value;
events.$params.orderBy = "DateTime";
events.$dataSource = new Event.DataSources.BlobLoader();
events.$load();
const eventsLength = computed(() => events.$pageCount!);

watch(eventsPageSize, () => {
  events.$pageSize = eventsPageSize.value;
  events.$load();
});

function movePrev() {
  if (events.$hasPreviousPage) {
    events.$previousPage();
    events.$load();
  }
}

function moveNext() {
  if (events.$hasNextPage) {
    events.$nextPage();
    events.$load();
  }
}

function goto(pageNum: number) {
  if (pageNum <= eventsLength.value && pageNum >= 1) {
    events.$page = pageNum;
    events.$load();
  }
}
</script>
