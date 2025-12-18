export function TaskCard({ task }) {
    const statusMap = {
        1: "Pending",
        2: "Completed",
        3: "Expired"
    };

    const statusColors = {
        1: "#f59e0b",
        2: "#10b981",
        3: "#ef4444"
    };

    return (
        <div className="card" style={{ marginBottom: 12 }}>
            <h3>{task.title}</h3>

            <p>
                Status:{" "}
                <strong style={{ color: statusColors[task.status] }}>
                    {statusMap[task.status]}
                </strong>
            </p>

            <p>
                SLA: <strong>{task.slaInHours}h</strong>
            </p>
        </div>
    );
}
