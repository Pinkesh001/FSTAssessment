const BASE_URL = "http://localhost:56013/api/orders"; 
// Adjust port to your backend Swagger port
export const searchOrders = async (query: string) => {
  const res = await fetch(`${BASE_URL}?query=${query}`);
  if (!res.ok) throw new Error("Search failed");
  return res.json();
};

export const getOrder = async (id: string) => {
  const res = await fetch(`${BASE_URL}/${id}`);
  if (!res.ok) throw new Error("Fetch failed");
  return res.json();
};

export const addNote = async (id: string, author: string, message: string) => {
  const res = await fetch(`${BASE_URL}/${id}/notes`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ author, message }),
  });

  if (!res.ok) throw new Error("Add note failed");
};

export const updateStatus = async (id: string, status: string) => {
  const res = await fetch(`${BASE_URL}/${id}/status`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ status }),
  });

  if (!res.ok) throw new Error("Update status failed");
};