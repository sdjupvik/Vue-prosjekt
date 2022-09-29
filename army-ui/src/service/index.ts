import axios, { type AxiosRequestConfig } from "axios";

axios.defaults.baseURL = "https://localhost:5001";

export async function apiGet(path: string) {
  let response = await axios.get(`/api/${path}`);
  return response.data;
}

export async function apiPut(path: string, data?: object) {
  let response = await axios.put(`/api/${path}`, data);
  return response.data;
}

export async function apiPost(path: string, data: object) {
  let response = await axios.post(`/api/${path}`, data);
  return response.data;
}

export async function apiDelete(path: string) {
  let response = await axios.delete(`/api/${path}`);
  return response.data;
}

export async function getProfilePicturePath() {
  let fileName = await apiGet("settings/profile-picture");
  return `${axios.defaults.baseURL}/profile-pictures/${fileName}`;
}

export async function uploadImage(body: FormData) {
  await fetch(`${axios.defaults.baseURL}/api/settings/profile-picture`, {
    method: "POST",
    body,
  });
}
