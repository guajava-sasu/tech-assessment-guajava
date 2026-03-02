import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom/client';


const AdminPage = () => {
    const [user, setUser] = useState<{ login: string; role: string } | null>(null);

    useEffect(() => {
        fetch('/_api/admin/me')
            .then(res => res.json())
            .then(data => setUser(data))
            .catch(() => setUser(null));
    }, []);

    const handleLogout = async () => {
        await fetch('/_api/admin/logout', { method: 'POST' });
        setUser(null);
        window.location.href = '/admin/login';
    };

    if (!user) {
        return <div>Veuillez vous connecter.</div>;
    }

    return (
        <div>
            Login
        </div>
    );
};

const root = ReactDOM.createRoot(document.getElementById("react-app") as HTMLElement);
root.render(<AdminPage />);
