export function TaskForm({ onSubmit }) {
    return (
        <div className="card" style={{ marginBottom: 24 }}>
            <h2>Nova Task</h2>

            <form onSubmit={onSubmit}>
                <div className="form-group">
                    <label>Título</label>
                    <input name="title" required />
                </div>

                <div className="form-group">
                    <label>SLA (horas)</label>
                    <input
                        name="slaInHours"
                        type="number"
                        min="1"
                        required
                    />
                </div>


                <div className="form-group">
                    <label>Arquivo</label>
                    <input name="file" type="file" />
                </div>

                <button type="submit">Criar Task</button>
            </form>
        </div>
    );
}
