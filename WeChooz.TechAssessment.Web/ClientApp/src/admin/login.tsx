import  { useState, useEffect } from 'react';
import ReactDOM from "react-dom/client";
 

type AdminUser = { login: string; role: string };

const AdminPage = () => {
    const [user, setUser] = useState<AdminUser | null>(null);
    const [login, setLogin] = useState('');
    const [error, setError] = useState<string | null>(null);
    const [isSubmitting, setIsSubmitting] = useState(false);

    useEffect(() => {
        (async () => {
            try {
                const res = await fetch('/_api/admin/me', { credentials: 'include' });
                if (!res.ok) {
                    setUser(null);
                    return;
                }

                const data = (await res.json()) as AdminUser;
                setUser(data);
            } catch {
                setUser(null);
            }
        })();
    }, []);

    const handleLogout = async () => {
        await fetch('/_api/admin/logout', { method: 'POST', credentials: 'include' });
        setUser(null);
        window.location.href = '/admin/login';
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const trimmed = login.trim();
        if (!trimmed) {
            setError('Login cannot be empty.');
            return;
        }

        setIsSubmitting(true);
        setError(null);

        try {
            const response = await fetch('/_api/admin/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                credentials: 'include',
                body: JSON.stringify({ login: trimmed })
            });

            if (response.ok) {
                window.location.href = '/admin';
                return;
            }

            setError('Login failed');
        } catch {
            setError('Login failed');
        } finally {
            setIsSubmitting(false);
        }
    };

    if (user) {
        return (
            <div>
                <h1>Admin</h1>
                <p>
                    Connecté en tant que <strong>{user.login}</strong> (rôle: <strong>{user.role}</strong>)
                </p>
                <button type="button" onClick={handleLogout}>
                    Se déconnecter
                </button>
            </div>
        );
    }

    return (
        <div>
            <h1>Login</h1>
            <form id="loginForm" onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="login"
                    placeholder="Login (formation ou sales)"
                    required
                    value={login}
                    onChange={(e) => setLogin(e.target.value)}
                    disabled={isSubmitting}
                />
                <button type="submit" disabled={isSubmitting}>
                    Se connecter
                </button>
                {error ? <div style={{ color: 'crimson', marginTop: 8 }}>{error}</div> : null}
            </form>
        </div>
    );
};

const root = ReactDOM.createRoot(document.getElementById('react-app') as HTMLElement);
root.render(<AdminPage />);
