<template>
  <v-card>
    <v-sheet color="primary">
      <v-card-title>Announcements</v-card-title>
    </v-sheet>
    <v-list-item v-for="announcement in announcements.$items" :key="announcement.$stableId"
      :to="`/announcementview/${announcement.announcementId}`">
      <v-list-item-title>
        {{ announcement.title }}
      </v-list-item-title>
      <v-list-item-subtitle>
        {{ getAnnouncementDesc(announcement.description) }}
      </v-list-item-subtitle>
      <template v-slot:append>
        <v-list-item-subtitle>
          {{ announcement.datePosted?.toDateString() }}
        </v-list-item-subtitle>
        &nbsp;
        <v-list-item-subtitle>
          {{ ` ${announcement.datePosted?.toLocaleTimeString()}` }}
        </v-list-item-subtitle>
      </template>
    </v-list-item>
  </v-card>
  <v-pagination v-model="announcementsPage" :length="announcementsLength" @update:model-value="goto" @prev="movePrev"
    @next="moveNext" />
</template>

<script setup lang="ts">
import { Announcement } from '@/models.g';
import { AnnouncementListViewModel } from '@/viewmodels.g';

const announcementsPage = ref(1);
const announcements = new AnnouncementListViewModel();
announcements.$pageSize = 5;
announcements.$params.orderByDescending = "DatePosted";
announcements.$load();
const announcementsLength = computed(() => announcements.$pageCount!);

function movePrev() {
  if (announcements.$hasPreviousPage) {
    announcements.$previousPage();
    announcements.$load();
  }
}

function moveNext() {
  if (announcements.$hasNextPage) {
    announcements.$nextPage();
    announcements.$load();
  }
}

function goto(pageNum: number) {
  if (pageNum <= announcementsLength.value && pageNum >= 1) {
    announcements.$page = pageNum;
    announcements.$load();
  }
}

function getAnnouncementDesc(desc: string | null) {
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