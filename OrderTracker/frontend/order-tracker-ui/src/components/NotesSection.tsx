import { useState } from "react";
import type { Order } from "../types/order";
import { addNote } from "../api/orderApi";

interface Props {
  order: Order;
  refresh: () => void;
}

const NotesSection = ({ order, refresh }: Props) => {
  const [message, setMessage] = useState("");
  const [loading, setLoading] = useState(false);

  const handleSubmit = async () => {
    if (message.length > 500) {
      alert("Note cannot exceed 500 characters");
      return;
    }

    try {
      setLoading(true);
      await addNote(order.id, "Support", message);
      setMessage("");
      refresh();
    } catch {
      alert("Failed to add note");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Support Notes</h3>

      {order.notes.map((note, index) => (
        <div key={index} style={{ borderBottom: "1px solid #ddd", marginBottom: 10 }}>
          <strong>{note.author}</strong>
          <p>{note.message}</p>
          <small>{new Date(note.createdAt).toLocaleString()}</small>
        </div>
      ))}

      <textarea
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        placeholder="Add note..."
        rows={3}
        style={{ width: "100%" }}
      />
      <button onClick={handleSubmit} disabled={loading}>
        {loading ? "Adding..." : "Add Note"}
      </button>
    </div>
  );
};

export default NotesSection;