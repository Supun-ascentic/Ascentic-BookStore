import * as React from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import axios from 'axios';

import { Layout,Card, } from 'antd';
import "antd/dist/antd.css";

const {Content,Sider} = Layout;
const {Meta} = Card;

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number,
    book: any;
    loading: false,
}

class ViewBookDetails extends React.Component<RouteComponentProps<any>, IFormState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            book: {},
            loading: false
        }
    }

    public componentDidMount(): void {
        axios.get(`https://localhost:44359/api/Book/${this.state.id}`).then(data => {
            this.setState({ book: data.data });
            console.log(data);
        })
    }



    public render() {
        const {  loading } = this.state;
        const book = this.state.book;
        return (
            <div style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
               <Layout style={{background: '#fff', padding: 24,marginBottom:20, minHeight: 800 }}>
                    <Sider style={{background: '#222',maxWidth:900}}>
                        <Card
                            hoverable
                            style={{ width: 240,minHeight: 460}}
                            cover={<img alt="example" src={book.photoURL?book.photoURL:"/book-cover-placeholder.jpg"} />}
                        >
                        <Meta title={book.title} />
                            <div style={{display: 'flex', paddingTop: 8 }}>
                            <b>Author :</b> 
                            {book.bookAuthor && book.bookAuthor.map((authorData: any) =>
                            <p style={{paddingLeft:5}} key={authorData.author.id}>{authorData.author.name}</p>
                            )}
                            </div>
                        
                        <h4 style={{ paddingTop: 8 }}>${book.price}</h4>
                        </Card>
                    </Sider>
                    <Content>Content</Content>
                </Layout>
           </div>
        )
    }
}
export default withRouter(ViewBookDetails)