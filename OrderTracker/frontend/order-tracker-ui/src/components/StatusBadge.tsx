interface Props {
  status: string;
}

const StatusBadge = ({ status }: Props) => {
  const getColor = () => {
    switch (status) {
      case "PLACED":
        return "gray";
      case "PAID":
        return "blue";
      case "SHIPPED":
        return "orange";
      case "DELIVERED":
        return "green";
      case "CANCELLED":
        return "red";
      default:
        return "black";
    }
  };

  return (
    <span style={{ color: "white", background: getColor(), padding: "5px 10px", borderRadius: 5 }}>
      {status}
    </span>
  );
};

export default StatusBadge;