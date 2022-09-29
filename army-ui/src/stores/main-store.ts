import { defineStore } from "pinia";
import { apiGet, apiDelete, getProfilePicturePath } from "@/service";
import type IMasterData from "@/models/IMasterData";

export const useMainStore = defineStore({
  id: "main",
  state: () => ({
    isLoading: false,
    profilePictureUrl: "",
    selectedFilterTypeKey: "mission",
    filters: [
      {
        type: "mission",
        data: [
          { id: 0, name: "All" },
          { id: 1, name: "Planning" },
          { id: 2, name: "In Progress" },
          { id: 3, name: "Successful" },
          { id: 4, name: "Failed" },
        ] as IMasterData[],
        selectedFilter: { id: 0, name: "All" } as IMasterData,
      },
      {
        type: "soldier",
        data: [
          { id: 0, name: "All" },
          { id: 1, name: "Major" },
          { id: 2, name: "Kaptein" },
          { id: 3, name: "Korporal" },
          { id: 4, name: "Visekorporal" },
        ] as IMasterData[],
        selectedFilter: { id: 0, name: "All" } as IMasterData,
      },
      {
        type: "weapon",
        data: [
          { id: 0, name: "All" },
          { id: 1, name: "Machine Gun" },
          { id: 2, name: "Missile" },
          { id: 3, name: "Bomb" },
          { id: 4, name: "Pistol" },
          { id: 5, name: "Rifle" },
        ] as IMasterData[],
        selectedFilter: { id: 0, name: "All" } as IMasterData,
      },
    ],
    missions: [],
    soldiers: [],
    weapons: [],
    soldierExpertises: [],
  }),
  getters: {
    selectedFilterType: (state) => {
      let t = state.filters.find((x) => x.type === state.selectedFilterTypeKey);
      if (!t) throw "this wont be null";
      return t;
    },
    filteredMissions: (state) => {
      let selectedFilterType = state.filters.find(
        (x) => x.type === state.selectedFilterTypeKey
      );

      if (selectedFilterType?.selectedFilter.name === "All")
        return state.missions;
      else
        return state.missions.filter(
          (x: any) =>
            x.missionStatus.id === selectedFilterType?.selectedFilter.id
        );
    },
    filteredSoldiers: (state) => {
      let selectedFilterType = state.filters.find(
        (x) => x.type === state.selectedFilterTypeKey
      );

      if (selectedFilterType?.selectedFilter.name === "All")
        return state.soldiers;
      else
        return state.soldiers.filter(
          (x: any) => x.soldierRank.id === selectedFilterType?.selectedFilter.id
        );
    },
    filteredWeapons: (state) => {
      let selectedFilterType = state.filters.find(
        (x) => x.type === state.selectedFilterTypeKey
      );

      if (selectedFilterType?.selectedFilter.name === "All")
        return state.weapons;
      else
        return state.weapons.filter(
          (x: any) => x.weaponType.id === selectedFilterType?.selectedFilter.id
        );
    },
  },
  actions: {
    changeFilter(filterId: number) {
      let filter = this.selectedFilterType?.data.find((x) => x.id == filterId);

      let selectedFilter = this.filters.find(
        (x) => x.type === this.selectedFilterTypeKey
      )?.selectedFilter;

      selectedFilter = filter;
    },
    async loadMissions() {
      this.isLoading = true;
      this.missions = await apiGet("mission");
      this.isLoading = false;
    },
    async loadSoldiers() {
      this.isLoading = true;
      this.soldiers = await apiGet("soldier");
      this.isLoading = false;
    },
    async loadWeapons() {
      this.isLoading = true;
      this.weapons = await apiGet("weapon");
      this.isLoading = false;
    },
    async loadSoldierExpertise() {
      this.soldierExpertises = await apiGet("soldier/expertise");
    },
    async deleteMission(id: number) {
      await apiDelete(`mission/${id}`);
      await this.loadMissions();
    },
    async deleteSoldier(id: number) {
      await apiDelete(`soldier/${id}`);
      await this.loadSoldiers();
    },
    async deleteWeapon(id: number) {
      await apiDelete(`weapon/${id}`);
      await this.loadWeapons();
    },
    async loadProfilePicture() {
      let fileName = await getProfilePicturePath();
      this.profilePictureUrl = fileName;
    },
  },
});
