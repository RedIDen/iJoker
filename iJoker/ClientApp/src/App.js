import React, { useEffect, useState } from 'react';
import './custom.css';
import LikeButton from "./components/LikeButton";

const App = () => {
    const [jokes, setJokes] = useState([]);

    useEffect(() => {
        fetch("api/jokes")
            .then(response => {
                return response.json();
            })
            .then(responseJson => {
                setJokes(responseJson);
            })
    }, []);

    return (
        <div>
            <div className="header">
                <h1 className="border px-4 py-2">
                    iJokes
                </h1>
            </div>
            <div className="container mx-auto px-5 w-50">
                {
                    jokes.map(joke => (
                        <div className="border rounded-4 hover-shadow my-3 p-4">
                            <h3>
                                {joke.author}
                            </h3>
                            <p>{joke.creationTime}</p>
                            <p>{joke.text}</p>
                            <div className="d-flex justify-content-between">
                                <LikeButton likes={joke.likes} />
                                <button className="btn">
                                    <img width="20px" src="https://cdn-icons-png.flaticon.com/512/2990/2990295.png" alt="" />
                                </button>
                            </div>
                        </div>
                    ))
                }
            </div>
        </div>
    );
}

export default App;
