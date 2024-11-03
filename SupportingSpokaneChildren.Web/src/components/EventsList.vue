<template>
  <v-card>
    <v-sheet color="primary">
      <v-card-title>Events</v-card-title>
    </v-sheet>
  </v-card>
  <v-row>
    <v-card class="my-5 mx-auto pa-3" v-for="event in events.$items" :key="event.$stableId"
      :to="`/eventview/${event.eventId}`">
      <v-img aspect-ratio="10/10" :width="230" src="https://cdn.vuetifyjs.com/images/cards/sunshine.jpg" cover />
      <v-card-title> {{ event.eventName }}</v-card-title>
      <v-card-subtitle> {{ event.location }}</v-card-subtitle>
      <v-card-subtitle>{{ `${event.dateTime?.toDateString()} ${event.dateTime?.toLocaleTimeString()}`
        }}</v-card-subtitle>
    </v-card>

  </v-row>
  <v-pagination v-model="eventsPage" :length="eventsLength" @update:model-value="goto" @prev="movePrev"
    @next="moveNext" />
</template>

<script setup lang="ts">
import { EventListViewModel } from '@/viewmodels.g';
import { useDisplay } from 'vuetify/lib/framework.mjs';

const display = ref(useDisplay());
const eventsPage = ref(1);
const events = new EventListViewModel();
const eventsPageSize = computed(() => {
  switch (display.value.name) {
    case 'xs': return 1;
    case 'sm':
    case 'md': return 2;
    case 'lg': return 3;
    case 'xl': return 4;
    case 'xxl': return 5;
  }
})
events.$pageSize = eventsPageSize.value;
events.$params.orderBy = "DateTime";
events.$load();
const eventsLength = computed(() => events.$pageCount!);

watch(eventsPageSize, () => {
  events.$pageSize = eventsPageSize.value;
  events.$load();
})

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

function getEventsDesc(desc: string | null) {
  if (desc === null) {
    return '';
  }
  let result = desc.slice(0, 30);
  if (result.length === 30) {
    result += '...';
  }
  return result;
}
</script>