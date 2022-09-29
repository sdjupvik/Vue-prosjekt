export function formatDate(dateString: string | null): string {
  return dateString
    ? Intl.DateTimeFormat("nb").format(new Date(dateString))
    : "";
}
